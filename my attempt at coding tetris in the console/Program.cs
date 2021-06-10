using System;
using System.Net;
using System.Timers;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace my_attempt_at_coding_tetris_in_the_console
{
    class Program
    {

        static int width = 10;
        static int height = 20;

        static int[,] grid = 
        {

            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

        };

        static readonly int[,,,] tetriminocodes =
        {
            //I
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 1, 1 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {1, 1, 1, 1, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                }

            },
            
            //J
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 1, 0, 0, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 0, 0, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                }

            },
            
            //L
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 1, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 1, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                }

            },

            //O
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                }

            },

            //S
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 1, 0, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

            },

            //T
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 1, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                }

            },

            //Z
            {

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 1, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 1, 1, 0, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 0, 0 }
                },

                {
                    {0, 0, 0, 0, 0 },
                    {0, 0, 0, 1, 0 },
                    {0, 0, 1, 1, 0 },
                    {0, 0, 1, 0, 0 },
                    {0, 0, 0, 0, 0 }
                }

            }

        };

        static readonly int[] LEFT = { -1, 0 };
        static readonly int[] RIGHT = { 1, 0 };
        static readonly int[] DOWN = { 0, 1 };
        static readonly int[] UP = { 0, -1 };

        static readonly int confirmtime = 500;
        public struct movingtetrimino
        { 
            public string tetid;

            public int[] prevpos;
            public int[] currentpos;

            public bool moving;

            public bool BTB;
        };

        static movingtetrimino movt = new movingtetrimino();

        static bool gameOver = false;

        static int score = 0;
        static int level = 0;
        static readonly int[] ScoreGivenForNumberOfLinesCleared = { 100, 300, 500, 800 };
        static readonly int[] ScoreGivenForCertainActions = {100, 200, 300, 400, 500, 600, 800, 1200, 1600, 1800, 2400, 0, 1, 2 };

        static Stopwatch DropTimer = new Stopwatch();
        static Stopwatch ConfirmTimer = new Stopwatch();
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            movt.prevpos = new int[2];
            movt.currentpos = new int[2];

            movt.moving = false;

            movt.BTB = false;

            SetTetrimino();

            DropTimer.Start();
            while (!gameOver)
            {
                ConsoleKeyInfo input;

                if (Console.KeyAvailable)
                {
 
                    input = Console.ReadKey(true);
                    Input(input.KeyChar);

                }

                if (DropTimer.ElapsedMilliseconds > 200)
                {
                    DropTimer.Reset();
                     
                    if (!movt.moving)
                        SetTetrimino();

                    movt.prevpos = movt.currentpos;

                    if (IfTetriminoCanMove(DOWN, movt.tetid, movt.currentpos))
                        movt.currentpos[1]++;
                    else
                    {

                        bool canceltimer = false;
                        ConfirmTimer.Reset();

                        while (movt.moving && !canceltimer)
                        {

                            ConfirmTimer.Start();

                            if (Console.KeyAvailable && ConfirmTimer.ElapsedMilliseconds <= confirmtime)
                            {

                                input = Console.ReadKey(true);
                                Input(input.KeyChar);
                                ConfirmTimer.Reset();
                                if (IfTetriminoCanMove(DOWN, movt.tetid, movt.currentpos))
                                    canceltimer = true;
                            }
                            else if (ConfirmTimer.ElapsedMilliseconds > confirmtime)
                            {
                                movt.moving = false;
                            }

                           
                            DrawTetriminoOntoGrid();
                            UpdateScreen();

                        }

                        if (!canceltimer)
                        {
                            PrintTetriminoOntoGrid();
                            CheckForClearedRow(movt.tetid, movt.currentpos);
                            SetTetrimino();
                        }
                        

                    }

                    DropTimer.Start();
                    
                }

                DrawTetriminoOntoGrid();
                UpdateScreen();

            }

            Console.ReadLine();
        }

        static void UpdateScreen()
        {
            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[y, x] == 0)
                        Console.Write("□ ");
                    else if (grid[y, x] == 1 || grid[y, x] == 2)
                        Console.Write("■ ");
                }
                Console.WriteLine();
            }
        }

        static void DrawTetriminoOntoGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y >= 0 && y < height && x >= 0 && x < width && grid[y, x] == 1)
                        grid[y, x] = 0;
                }
            }

            for (int y = movt.currentpos[1]; y < movt.currentpos[1] + 5; y++)
            {
                for (int x = movt.currentpos[0]; x < movt.currentpos[0] + 5; x++)
                {
                    if (y >= 0 && y < height && x >= 0 && x < width && tetriminocodes[(int)Char.GetNumericValue(movt.tetid, 0), (int)Char.GetNumericValue(movt.tetid, 1), y - movt.currentpos[1], x - movt.currentpos[0]] == 1)
                        grid[y, x] = 1;
                }
            }

        }

        static void PrintTetriminoOntoGrid()
        {
            for (int y = movt.currentpos[1]; y < movt.currentpos[1] + 5; y++)
            {
                for (int x = movt.currentpos[0]; x < movt.currentpos[0] + 5; x++)
                {
                    if (y >= 0 && y < height && x >= 0 && x < width && tetriminocodes[(int)Char.GetNumericValue(movt.tetid, 0), (int)Char.GetNumericValue(movt.tetid, 1), y - movt.currentpos[1], x - movt.currentpos[0]] == 1)
                        grid[y, x] = 2;
                }
            }
        }

        static bool Input(char input)
        {

            int rotation = (int)Char.GetNumericValue(movt.tetid, 1);

            if (input == 'd')
            { 
                if (IfTetriminoCanMove(RIGHT, movt.tetid, movt.currentpos))
                {
                    movt.currentpos[0]++;
                    return true;
                }
            
            }
            if (input == 'a')
            {
                if (IfTetriminoCanMove(LEFT, movt.tetid, movt.currentpos))
                {
                    movt.currentpos[0]--;
                    return true;
                }
            }

            if (input == 'w')
            {

                char[] ch = movt.tetid.ToCharArray();

                if ((int)Char.GetNumericValue(movt.tetid, 1) != 3)
                    ch[1] = Convert.ToChar(rotation + 1 + 48);
                
                else
                    ch[1] = '0';
                

                if (IfTetriminoCanRotate((int)Char.GetNumericValue(ch[1]), movt.tetid, movt.currentpos, out int[] newpos))
                    movt.tetid = new string(ch);

                movt.currentpos = newpos;

                return true;
            }
            if (input == 's')
            {

                char[] ch = movt.tetid.ToCharArray();

                if ((int)Char.GetNumericValue(movt.tetid, 1) != 0)
                    ch[1] = Convert.ToChar(rotation - 1 + 48);

                else
                    ch[1] = '3';

                if (IfTetriminoCanRotate((int)Char.GetNumericValue(ch[1]), movt.tetid, movt.currentpos, out int[] newpos))
                    movt.tetid = new string(ch);

                movt.currentpos = newpos;

                return true;
            }
            if (input == ' ')
            {
                DropTetrimino();
                return true;
            }

            return false;

        }
        static bool IfTetriminoCanMove(int[] direction, string tetid, int[] cpos)
        {

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (tetriminocodes[(int)Char.GetNumericValue(tetid, 0), (int)Char.GetNumericValue(tetid, 1), y, x] == 1)
                    {
                        if (cpos[1] + y + direction[1] >= height || cpos[0] + x + direction[0] < 0 || cpos[0] + x + direction[0] >= width)
                            return false;
                        if (cpos[1] + direction[1] > -1)
                            if (grid[cpos[1] + y + direction[1], cpos[0] + x + direction[0]] == 2)
                                return false;
                    }
                }
            }
            return true;
        }

        static bool IfTetriminoCanRotate(int rotation, string tetid, int[] cpos, out int[] newpos)
        {

            bool CanRotateInOriginalPosition = true;
            bool CanRotateInLeftPosition = true;
            bool CanRotateInRightPosition = true;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (tetriminocodes[(int)Char.GetNumericValue(tetid, 0), rotation, y, x] == 1)
                    {
                        if (cpos[1] < 0)
                        {
                            newpos = cpos;
                            return false;
                        }

                        else if (cpos[1] + y >= height)
                        {
                            if (CanKick(UP, tetid, rotation, cpos))
                                cpos[1]--;
                            else
                                CanRotateInOriginalPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x < 0)
                        {
                            if (CanKick(RIGHT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInOriginalPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x >= width)
                        {
                            if (CanKick(LEFT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInOriginalPosition = false;

                            y = 5; x = 5;

                        }
                        else if (grid[cpos[1] + y, cpos[0] + x] == 2)
                        {
                            CanRotateInOriginalPosition = false;
                            y = 5; x = 5;
                        }
                    }
                }
            }

            if (CanRotateInOriginalPosition)
            {
                newpos = cpos;
                return true;
            }
                

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (tetriminocodes[(int)Char.GetNumericValue(tetid, 0), rotation, y, x] == 1)
                    {
                        if (cpos[1] + y >= height)
                        {
                            if (CanKick(UP, tetid, rotation, cpos))
                                cpos[1]--;
                            else
                                CanRotateInRightPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x  + 1 < 0)
                        {
                            if (CanKick(RIGHT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInRightPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x + 1 >= width)
                        {
                            if (CanKick(LEFT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInRightPosition = false;

                            y = 5; x = 5;

                        }

                        else if (grid[cpos[1] + y, cpos[0] + x + 1] == 2)
                        {
                            CanRotateInRightPosition = false;
                            y = 5; x = 5;
                        }
                    }
                }
            }

            if (CanRotateInRightPosition)
            {
                newpos = new int[2] { cpos[0] + 1, cpos[1] };
                return true;
            }

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (tetriminocodes[(int)Char.GetNumericValue(tetid, 0), rotation, y, x] == 1)
                    {
                        if (cpos[1] + y >= height)
                        {
                            if (CanKick(UP, tetid, rotation, cpos))
                                cpos[1]--;
                            else
                                CanRotateInLeftPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x - 1 < 0)
                        {
                            if (CanKick(RIGHT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInLeftPosition = false;

                            y = 5; x = 5;

                        }
                        else if (cpos[0] + x - 1 >= width)
                        {
                            if (CanKick(LEFT, tetid, rotation, cpos))
                                cpos[0]++;
                            else
                                CanRotateInLeftPosition = false;

                            y = 5; x = 5;

                        }

                        else if (grid[cpos[1] + y, cpos[0] + x - 1] == 2)
                        {
                            CanRotateInLeftPosition = false;
                            y = 5; x = 5;
                        }
                    }
                }
            }

            if (CanRotateInLeftPosition)
            {
                newpos = new int[2] { cpos[0] - 1, cpos[1] };
                return true;
            }

            newpos = cpos;
            return false;
        }

        static bool CanKick(int[] direction, string tetid, int rotation, int[] cpos)
        {

            char[] ch = tetid.ToCharArray();
            ch[1] = Convert.ToChar(rotation + 48);
            tetid = new string(ch);

            return IfTetriminoCanMove(direction, tetid, cpos); 

        }

        static void DropTetrimino()
        {
            while (IfTetriminoCanMove(DOWN, movt.tetid, movt.currentpos))
            {
                movt.currentpos[1]++;
            } 

            PrintTetriminoOntoGrid();
            CheckForClearedRow(movt.tetid, movt.currentpos);
            SetTetrimino();

        }

        static void CheckForClearedRow(string tetid, int[] cpos)
        {

            bool cleared;

            for (int y = 0; y < 5; y++)
            {

                if (cpos[0] + y < height)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        if (tetriminocodes[(int)Char.GetNumericValue(tetid, 0), (int)Char.GetNumericValue(tetid, 1), y, x] == 1)
                        {

                            x = 5;
                            cleared = true;

                            for (int i = 0; i < width; i++)
                            {
                                if (grid[cpos[1] + y, i] != 2)
                                {
                                    cleared = false;
                                    i = width;
                                }
                            }

                            if (cleared)
                            {
                                ClearRow(cpos[1] + y);
                            }

                        }
                    }
                }
             
            }
        }

        static void ClearRow(int row)
        {
            for (int i = 0; i < width; i++)
                grid[row, i] = 0;

            for (int y = row - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y + 1, x] = grid[y, x];
                    grid[y, x] = 0;
                }
            }

        }

        static void SetTetrimino()
        {
            Random rnd = new Random();
            movt.tetid = rnd.Next(0, 6).ToString() + 0;

            movt.moving = true;

            if (movt.tetid[0] == '0' || movt.tetid[0] == '3')
                movt.currentpos[0] = 2;
            else
                movt.currentpos[0] = 3;

            movt.currentpos[1] = -2;
            movt.prevpos = movt.currentpos;
        }

    }
}
