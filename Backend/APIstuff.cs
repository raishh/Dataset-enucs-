using System;
using System.IO;
using System.Collections.Generic;
using DataLayer;

namespace Backend
{
    //Class for API interaction
    public class APIstuff
    {
        //static method for a map api request, specfically for a UFO sighting list
        public static string UFORequest()
        {

            return "hello";
        }

        //NEW STUFF BELOW

        //Local copy
        private static List<UFO> dataCopy = new List<UFO>();
        
        
        //UFOLoader
        public static void UFOInstance(string txtDir)
        {
            UFOLoader input = new UFOLoader(txtDir);
            CorruptionCheck(input);
        }
        //Discards all records with broken date
        private static void CorruptionCheck(UFOLoader input)
        {
            foreach (var item in input.UFOData)
            {
                if (item.date_spotted.Contains("/"))
                {
                    dataCopy.Add(item);
                }
            }
        }    
        
        
    }
}
