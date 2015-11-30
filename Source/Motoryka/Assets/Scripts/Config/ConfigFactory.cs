﻿using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;
using System.Collections.Generic;

public class ConfigFactory 
{
	public static Config CreateNewConfig()
	{
		Config config = new Config { 
			Id = 0, 
			Name = "Nazwa",
			CreationDate = DateTime.Now, 
			DrawStartPoint = true,
			NrOfLevels = 2,
			WaitingTime = 3f,
			Levels = new List<LevelConfig>()
		};
		var level1 = new LevelConfig { levelNumber = 1, shape = Shape.HorizontalLine, lineStroke = LineStroke.Medium, shapeColor = PastelColorFactory.RandomColor };
		level1.brushColor = PastelColorFactory.RandomColorWithExclude(level1.shapeColor);
		config.Levels.Add (level1);
		var level2 = new LevelConfig { levelNumber = 2, shape = Shape.VerticalLine, lineStroke = LineStroke.Medium, shapeColor = PastelColorFactory.RandomColor };
		level2.brushColor = PastelColorFactory.RandomColorWithExclude(level2.shapeColor);
		config.Levels.Add (level2);

		return config;
	}

	public static Config CreateEasyLevel()
	{
		Config config = new Config { 
			Id = -3, 
			Name = "Łatwy poziom",
			CreationDate = DateTime.Now, 
			DrawStartPoint = true,
			NrOfLevels = 3,
            WaitingTime = 3f,
			Levels = new List<LevelConfig> {
				new LevelConfig { levelNumber = 1, shape = Shape.VerticalLine, lineStroke = LineStroke.VeryThick, shapeColor = PastelColorFactory.Blue, brushColor = PastelColorFactory.LightBlue },
				new LevelConfig { levelNumber = 2, shape = Shape.HorizontalLine, lineStroke = LineStroke.VeryThick, shapeColor = PastelColorFactory.Yellow, brushColor = PastelColorFactory.LightRed },
				new LevelConfig { levelNumber = 3, shape = Shape.DiagonalLine, lineStroke = LineStroke.Thick, shapeColor = PastelColorFactory.Green, brushColor = PastelColorFactory.Gray }
			}
		};
		return config;
	}

	public static Config CreateMediumLevel()
	{
		Config config = new Config { 
			Id = -2, 
			Name = "Średni poziom",
			CreationDate = DateTime.Now,
			DrawStartPoint = true,
			NrOfLevels = 9,
            WaitingTime = 2f,
			Levels = new List<LevelConfig> {
				new LevelConfig { levelNumber = 1, shape = Shape.VerticalLine, lineStroke = LineStroke.VeryThick, shapeColor = PastelColorFactory.LightYellow, brushColor = PastelColorFactory.LightBlue },
				new LevelConfig { levelNumber = 2, shape = Shape.HorizontalLine, lineStroke = LineStroke.Thick, shapeColor = PastelColorFactory.DarkBlue, brushColor = PastelColorFactory.LightPink },
				new LevelConfig { levelNumber = 3, shape = Shape.DiagonalLine, lineStroke = LineStroke.Medium, shapeColor = PastelColorFactory.Purple, brushColor = PastelColorFactory.LightGreen },
				new LevelConfig { levelNumber = 4, shape = Shape.CurvedLine, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.Green, brushColor = PastelColorFactory.DarkGray },
				new LevelConfig { levelNumber = 5, shape = Shape.Circle, lineStroke = LineStroke.VeryThin, shapeColor = PastelColorFactory.Blue, brushColor = PastelColorFactory.LightRed },
				new LevelConfig { levelNumber = 6, shape = Shape.Ellipse, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.Mint, brushColor = PastelColorFactory.Black },
				new LevelConfig { levelNumber = 7, shape = Shape.Triangle, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.Orange, brushColor = PastelColorFactory.Yellow },
				new LevelConfig { levelNumber = 8, shape = Shape.Square, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.LightBlue, brushColor = PastelColorFactory.LightRed },
				new LevelConfig { levelNumber = 9, shape = Shape.Rectangle, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.Purple, brushColor = PastelColorFactory.LightGreen }
			}
		};
		return config;
	}

	public static Config CreateHardLevel()
	{
		Config config = new Config { 
			Id = -1, 
			Name = "Trudny poziom",
			CreationDate = DateTime.Now,
			DrawStartPoint = false,
            NrOfLevels = 3,
            WaitingTime = 1f,
			Levels = new List<LevelConfig> {
				new LevelConfig { levelNumber = 1, shape = Shape.Triangle, lineStroke = LineStroke.Medium, shapeColor = PastelColorFactory.Pink, brushColor = PastelColorFactory.Yellow },
				new LevelConfig { levelNumber = 2, shape = Shape.Square, lineStroke = LineStroke.Thin, shapeColor = PastelColorFactory.Mint, brushColor = PastelColorFactory.Orange },
				new LevelConfig { levelNumber = 3, shape = Shape.Rectangle, lineStroke = LineStroke.VeryThin, shapeColor = PastelColorFactory.LightBlue, brushColor = PastelColorFactory.Orange }
			}
		};
		return config;
	}
}
