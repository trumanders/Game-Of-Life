
using System.Diagnostics;
using Microsoft.VisualBasic;
    namespace GOL
{
    // Rita ut levande celler -> de läggs i en 1D-list med Points aliveCellsPoints.
    // Bara de levande cellerna i aliveCellsPoints beräknas på. Har de 2 eller 3 grannar så överlever de.
    // Varje levande cells döda grannar kollas. Har de 3 grannar så kommer de till liv. Läggs till i aliveCellsPoints.
    // I aliveCellsPoints kan man inte kolla efter grannar på ett enkelt sätt. Därför läggs alla levande till i en 2D array: 
    // aliveDeadChecker. 1=alive 0=dead. Denna itereras inte genom i sin helhet, utan används för att kolla grannar.
    // Eftersom samma döda granne kan evalueras flera gånger  måste det kollas om den cellen redan lags till i makeAlive.
    // (isDuplicate).


    public partial class Form1 : Form
    {
        const string CELLCOUNT = "Cell Count: ";
        const string AVG_FRAME_TIME = "Avg Frame Time: ";
        const string INIT_CELLS = "Init. Cells: ";
        const string NUM_OF_GENERATIONS = "Num of gens: ";
        const int FORM_RESOLUTION_X = 2000;
        const int FORM_RESOLUTION_Y = 2000;
        const int SECOND = 1000;
        int genPerSec = 20;
        bool pencilDown;
        Point gridResolution;      
        int gridSquareSize;
        Rectangle[,] rectGrid;
        List<Point> aliveCellsPoints;       
        int[,] aliveDeadChecker;
        Brush deadBrush;
        Brush aliveBrush;
        Graphics g;
        bool eraseMode;     // Click dead cell: eraseMode = false. Click living cell: eraseMode = true
        double cellCount;
        int generationCount;
        double frameCount;
        double initialCells;
        double frameTimeSum;
        double maxPercent = -2000000000;
        double maxCells = -2000000000;
        int maxGrowthGeneration;
        double maxCellCount = 0;


        // Constructor
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
            aliveCellsPoints = new List<Point>();
            pencilDown = false;
            this.Width = FORM_RESOLUTION_X;
            this.Height = FORM_RESOLUTION_Y;
            gridResolution = new Point(400,400);
            gridSquareSize = this.Width / gridResolution.X;
            rectGrid = new Rectangle[gridResolution.X, gridResolution.Y];            
            aliveDeadChecker = new int[gridResolution.X, gridResolution.Y]; 
            deadBrush = new SolidBrush(Color.Black);
            aliveBrush = new SolidBrush(Color.White);
            cellCount = 0;
            generationCount = 1;

            // Initialize the grid rectangles
            for (int i = 0; i < rectGrid.GetLength(0); i++)
            {
                for (int j = 0; j < rectGrid.GetLength(1); j++)
                {
                    rectGrid[i, j] = new Rectangle(i * gridSquareSize, j * gridSquareSize, gridSquareSize, gridSquareSize);
                }
            }
            string input = Interaction.InputBox("Prompt", "Title", "Default", 10, 10);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.Clear(Color.Black);
        }



        // Update cell at mouse click
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            pencilDown = true;

            // Grid coordinates
            int x = e.X / gridSquareSize;
            int y = e.Y / gridSquareSize;

            // Handle draw outside grid
            x = DrawOutsideGrid(x);
            y = DrawOutsideGrid(y);

            // Add cell if clicked dead cell
            if (aliveDeadChecker[x, y] == 0)
                AddCell(x, y, g);

            // Remove cell if clicked living cell, and activate erase mode
            else
            {                
                RemoveCell(x, y, g);
                eraseMode = true;                
            }
            UpdateText();
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pencilDown = false;
            eraseMode = false;
        }

                
        // Update cell on MOUSE MOVE
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            // Grid coordinates
            int x = e.X / gridSquareSize;
            int y = e.Y / gridSquareSize;

            // If mouse button down
            if (pencilDown)
            {
                x = DrawOutsideGrid(x);
                y = DrawOutsideGrid(y);


                // If not erasing cells and moving to dead cell, then add cell
                if (!eraseMode && aliveDeadChecker[x, y] == 0)
                    AddCell(x, y, g);
             
                // If erasing cells, and moving to living cell, then remove cell
                else if (eraseMode && aliveDeadChecker[x, y] == 1)
                    RemoveCell(x, y, g);
                UpdateText();
            }
        }


        // Update the statistics
        private void UpdateText()
        {
            txtCellCount.Text = CELLCOUNT + cellCount.ToString();
            txtNumOfStartCells.Text = "Initial cells: " + cellCount.ToString();
        }


        // Method to handle drawing outside of the grid
        private int DrawOutsideGrid(int value)
        {            
            if (value > gridResolution.X - 1) value = gridResolution.X - 1;
            if (value < 0) value = 0;
            return value;
        }


        // Method to add and draw cell
        private void AddCell(int x, int y, Graphics g)
        {
            aliveCellsPoints.Add(new Point(x, y));
            aliveDeadChecker[x, y] = 1;
            g.FillRectangle(aliveBrush, rectGrid[x, y]);
            cellCount++;
        }


        // Method to remove and draw dead cell
        private void RemoveCell(int x, int y, Graphics g)
        {
            aliveDeadChecker[x, y] = 0;
            for (int i = 0; i < aliveCellsPoints.Count; i++)
            {
                if (aliveCellsPoints[i].X == x && aliveCellsPoints[i].Y == y)
                    aliveCellsPoints.RemoveAt(i);
            }
            g.FillRectangle(deadBrush, rectGrid[x, y]);
            cellCount--;
        }


        // Listen for key stroke
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                runSimLoop();
            }

            if (e.KeyChar == 'q')
            {
                this.Close();
            }
        }


        // START SIMULATION
        private void runSimLoop()
        {
            List<Point> kill = new List<Point>();       // Store coordinates of cells to remove
            List<Point> makeAlive = new List<Point>();  // Store coordinates of cells to make alive
            List<int> killIndexes = new List<int>();    // Store indexes of alive cells to remove

            // Set statistics
            initialCells = cellCount;
            maxCellCount = cellCount;
            //Graphics g = e.Graphics;
            Graphics g = this.CreateGraphics();


            // START LOOP
            
            txtNumOfStartCells.Text = initialCells.ToString();
            //txtNumOfStartCells.Refresh();
            while (true)
            {
                // Set current time to measure loop duration
                DateTime startTime = DateTime.Now;           
                
                // Iterate through living cells only
                for (int i = 0; i < aliveCellsPoints.Count; i++) 
                {                    
                    int neighbourCount = countNeighbours(aliveCellsPoints[i], gridResolution, aliveDeadChecker, true);

                    // If living cell has < 2 or > 3 neighbours, add cell to be removed
                    if (neighbourCount < 2 || neighbourCount > 3)
                    {
                        // Check if this alive cell is already added to be removed...
                        if (!isDuplicate(kill, aliveCellsPoints[i]))
                        {
                            // ...if not, add cell to kill list
                            kill.Add(aliveCellsPoints[i]);
                        }

                        // Store index to remove later in aliveCellsPoints
                        killIndexes.Add(i);
                    }
                }

                // Make changes: dead -> alive 
                for (int i = 0; i < makeAlive.Count; i++)
                {                   
                    aliveCellsPoints.Add(new Point(makeAlive[i].X, makeAlive[i].Y));
                    g.FillRectangle(aliveBrush, rectGrid[makeAlive[i].X, makeAlive[i].Y]);

                    // Update aliveDeadChecker
                    aliveDeadChecker[makeAlive[i].X, makeAlive[i].Y] = 1;
                    cellCount++;
                }

                // Make changes: alive -> dead
                if (kill.Count > 0) 
                {
                    for (int i = 0; i < kill.Count; i++)
                    {
                        g.FillRectangle(deadBrush, rectGrid[kill[i].X, kill[i].Y]);

                        // update aliveDeadChecker
                        aliveDeadChecker[kill[i].X, kill[i].Y] = 0;
                        cellCount--;
                    }

                    // Remove from aliveCellsPoints
                    for (int i = killIndexes.Count - 1; i >= 0; i--)
                    {
                        aliveCellsPoints.RemoveAt(killIndexes[i]);
                    }
                }                
                
                // clear stuff
                //Thread.Sleep(SECOND / genPerSec);               
                kill.Clear();
                makeAlive.Clear();
                killIndexes.Clear();

                // Measure loop time
                DateTime endTime = DateTime.Now;
                TimeSpan frameTime = endTime - startTime;
                frameCount++;
                frameTimeSum += frameTime.TotalMilliseconds;
                generationCount++;
                displayText();              
            }
        }

        double calcMaxCellCount()
        {
            if (cellCount > maxCellCount)
            {
                maxCellCount = cellCount;
            }
            return maxCellCount;
        }

        double growthPercent()
        {
            return ((cellCount - initialCells) / initialCells) * 100;
        }

        double growthCells()
        {
            return cellCount - initialCells;
        }

        double maxGrowthPercent()
        {
            double growth = growthPercent();
            if (growth > maxPercent)
            {
                maxPercent = growth;
                maxGrowthGeneration = generationCount;
            }
            return maxPercent;
        }

        double maxGrowthCells()
        {
            double growth = growthCells();
            if (growth > maxCells)
            {
                maxCells = growth;
            }
            return maxCells;
        }


        void displayText()
        {
            txtCellCount.Text = "CELL COUNT: " + cellCount.ToString();
            txtAvgFrameTime.Text = "AVG Frame Dur.: " + (Math.Round(frameTimeSum / frameCount)).ToString();
            txtGens.Text = "Gen. Count: " + generationCount;
            txtNumOfStartCells.Text = "Initial cells: " + initialCells.ToString();
            txtGrowthPercent.Text = "Growth %: " + Math.Round(growthPercent()).ToString();
            txtGrowthCells.Text = "Growth cells: " + Math.Round(growthCells()).ToString();
            txtMaxGrowthPercent.Text = "Max growth %: " + Math.Round(maxGrowthPercent()).ToString();
            txtMaxGrowthCells.Text = "Max growth cells: " + Math.Round(maxGrowthCells()).ToString();
            txtMaxGrowthGeneration.Text = "Max growth at gen: " + maxGrowthGeneration;
            txtMaxGrowthGeneration.Refresh();
            txtMaxCellCount.Text = "Max cell count: " + calcMaxCellCount().ToString();
            txtMaxCellCount.Refresh();
            txtGens.Refresh();
            txtCellCount.Refresh();
            txtAvgFrameTime.Refresh();
            txtGrowthPercent.Refresh();
            txtGrowthCells.Refresh();
            txtMaxGrowthCells.Refresh();
            txtMaxGrowthPercent.Refresh();
        }

        bool isDuplicate(List<Point> checkForDuplicate, Point checkPoint)
        {
            for (int i = 0; i < checkForDuplicate.Count; i++)
            {
                // if same point already added
                if (checkForDuplicate[i].X == checkPoint.X && checkForDuplicate[i].Y == checkPoint.Y)
                {
                    return true;
                }
            }
            return false;
        }


        void updateAliveDeadChecker(int[,] toBeUpdated, int[,] update)
        {
            for (int a = 0; a < toBeUpdated.GetLength(0); a++)
            {
                for (int b = 0; b < toBeUpdated.GetLength(1); b++)
                {
                    toBeUpdated[a, b] = update[a, b];
                }
            }
        }


        int countNeighbours(Point checkPoint, Point gridResolution, int[,] aliveDeadChecker, bool countNeighbourNeighbour)
        {
            int neighboursCount = 0;

            // Check one to the left  - to - one to the right
            for (int i = checkPoint.X - 1; i <= checkPoint.X + 1; i++)
            {
                // Don't check outside grid
                if (i < 0 || i > gridResolution.X - 1) { continue; }

                // Check one the the left - to - one to the right
                for (int j = checkPoint.Y - 1; j <= checkPoint.Y + 1; j++)
                {
                    // Don't check outside grid
                    if (j < 0 || j > gridResolution.Y - 1) { continue; }

                    // Don't check the cell itself (center)
                    if (i == checkPoint.X && j == checkPoint.Y) { continue; }

                    // If cell is alive
                    if (aliveDeadChecker[i, j] == 1) { neighboursCount++; }

                    // If dead, check that dead neighbours neighbours. If 3 of them are alive, make the neighbour alive
                    // Recursively
                    Point thisPoint = new Point(i, j);
                    if (countNeighbours(thisPoint, gridResolution, aliveDeadChecker, false) == 3)
                    {
                        if (!isDuplicate(makeAlive, thisPoint))
                        {
                            // ...if not, add cell to kill list
                            makeAlive.Add(aliveCellsPoints[i]);
                        }
                    }
                }
            }
            return neighboursCount;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAvgFrameTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}