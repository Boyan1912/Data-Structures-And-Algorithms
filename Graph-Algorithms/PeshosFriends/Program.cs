namespace PeshosFriends
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public enum Type
        {
            House = 0,
            Hospital = 1
        }

       public class Building
        {
            public Building(int id, Type type)
            {
                this.Id = id;
                this.Type = type;
                this.Neighbours = new Dictionary<Building, int>();
            }

            public int Id { get; set; }

            public Type Type { get; set; }

            public Dictionary<Building, int> Neighbours { get; set; }

            public void AddNeighbour(Building neighbour, int length)
            {
                if (!this.Neighbours.ContainsKey(neighbour))
                {
                    this.Neighbours[neighbour] = length;
                }
                if(!neighbour.Neighbours.ContainsKey(this))
                {
                    neighbour.Neighbours[this] = length;
                }
            }

            public bool HasPathTo(Building building)
            {
                return this.Neighbours.ContainsKey(building);
            }
        }

            //3 2 1 
            //1
            //1 2 1
            //3 2 2
            
        public static void Main()
        {

            string[] lineOne = Console.ReadLine().Split(' ');

            int buildingsCount = int.Parse(lineOne[0]);
            int streetsCount = int.Parse(lineOne[1]);
            int hospitalsCount = int.Parse(lineOne[2]);


            var buildings = new List<Building>();
            for (int i = 1; i <= buildingsCount; i++)
            {
                buildings.Add(new Building(i, Type.House));
            }

            string[] lineTwo = Console.ReadLine().Split(' ');

            for (int i = 0; i < hospitalsCount; i++)
            {
                int hospitalIndex = int.Parse(lineTwo[i]) - 1;
                buildings[hospitalIndex].Type = Type.Hospital;
            }

            for (int i = 0; i < streetsCount; i++)
            {
                string[] streetData = Console.ReadLine().Split(' ');
                int fromId = int.Parse(streetData[0]);
                int toId = int.Parse(streetData[1]);
                int streetLength = int.Parse(streetData[2]);
                var from = buildings.FirstOrDefault(b => b.Id == fromId);
                var to = buildings.FirstOrDefault(b => b.Id == toId);
                from.AddNeighbour(to, streetLength);
            }

            var hospitals = buildings.Where(b => b.Type == Type.Hospital).ToList();
            var houses = buildings.Where(b => b.Type == Type.House).ToList();

            int[] paths = new int[buildings.Count + 1];
            //for (int i = 0; i < paths.Length; i++)
            //{
            //    paths[i] = int.MaxValue;
            //}

            bool[] used = new bool[buildings.Count];

            var searchedHospital = hospitals.FirstOrDefault();

            while (hospitals.Count > 0)
            {
                var results = new List<int>();

                int searchedHospitalIndex = searchedHospital.Id - 1;
                hospitals.Remove(searchedHospital);

                int best = buildings.Count;

                
                for (int i = 0; i < buildings.Count; i++)
                {
                    paths[best] = int.MaxValue;
                    if (buildings[i].HasPathTo(buildings[searchedHospitalIndex]))
                    {
                        paths[best] = buildings[i].Neighbours[buildings[searchedHospitalIndex]];
                    }

                    for (int j = 0; j < buildings.Count; j++)
                    {
                        if (j != searchedHospitalIndex && i != searchedHospitalIndex && buildings[i].HasPathTo(buildings[j]))
                        {
                            paths[j] += buildings[i].Neighbours[buildings[j]];

                            int k = j - 1;
                            int l = j;
                            while (k >= 0 && !buildings[k].HasPathTo(buildings[searchedHospitalIndex]))
                            {
                                if (buildings[l].HasPathTo(buildings[k]))
                                {
                                    paths[j] += buildings[l].Neighbours[buildings[k]];
                                }
                                else
                                {
                                    break;
                                }
                                k--;
                                l--;
                            }
                            if (k >= 0 && buildings[k].HasPathTo(buildings[searchedHospitalIndex]))
                            {
                                paths[j] += buildings[k].Neighbours[buildings[searchedHospitalIndex]];
                            }

                            if (paths[j] < paths[best])
                            {
                                paths[best] = paths[j];
                            }

                        }
                        else if (j == searchedHospitalIndex && i != searchedHospitalIndex && buildings[i].HasPathTo(buildings[j]))
                        {
                            if (paths[j] + buildings[i].Neighbours[buildings[j]] < paths[best])
                            {
                                paths[best] = paths[j] + buildings[i].Neighbours[buildings[j]];
                            }
                        }

                    }
                    //used[i] = true;
                    results.Add(paths[best]);
                }
                results.Remove(int.MaxValue);
                Console.WriteLine(string.Join(" ", results));
                Console.WriteLine(results.Sum());
            }
            
        }
        
        
    }
}
