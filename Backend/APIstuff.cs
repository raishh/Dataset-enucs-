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
            string[] tempArr;
            string swap;
            UFO temp;
            foreach (var item in input.UFOData)
            {
                tempArr = item.date_spotted.Split('/',' ');

                swap = tempArr[0];
                tempArr[0] = tempArr[2];
                tempArr[2] = swap;

                swap = tempArr[1];
                tempArr[1] = tempArr[2];
                tempArr[2] = swap;
                
                if (tempArr[2].StartsWith("0"))
                {
                    tempArr[2] = Convert.ToString(Convert.ToInt32(tempArr[2]));
                }
                if (tempArr[1].StartsWith("0"))
                {
                    tempArr[1] = Convert.ToString(Convert.ToInt32(tempArr[1]));
                }
                temp = item;
                temp.date_spotted = tempArr[0] + "/" + tempArr[1] + "/" + tempArr[2]+" "+tempArr[3];
                dataCopy.Add(temp);
            }
            dataCopy.Sort((x, y) => x.date_spotted.CompareTo(y.date_spotted));
        }
       
        

        
        


    }
}
