using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace BomberMan.Client.Data
{
    public class GameLogic
    {
        [Inject] private HttpClient Http { get; set; }
        
        public static List<GameElement> CreateMap(char[][] charMap)
        {
            var map = new List<GameElement>();
            
            for (int i = 0; i < charMap.Length; i++)
            {
                for (int j = 0; j < charMap[i].Length; j++)
                {
                    char c = charMap[i][j];
                   
                    switch (c)
                    {
                        case 'X':
                            map.Add(new Wall("wall", i, j));
                            break;
                        case '.':
                            map.Add(new Grass("grass", i, j));
                            break;
                        case 'B':
                            map.Add(new Box("box", i, j));
                            break;
                        case 'P':
                            map.Add(new Grass("grass", i, j));
                            map.Add(new Player("player", i, j));
                            break;
                        case 'E':
                            map.Add(new Enemy("enemy", i, j));
                            break;
                        default:
                            throw new Exception($"Unknow character '{c}' in map");
                    }
                }
            }
            return map;
        }
    }
}