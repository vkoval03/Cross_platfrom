using _3_lab;

namespace Lab3Usage
{
    class Program
    {
        static void Main(string[] args)
        {

            string pathToInputFile = "../../../input.txt";

            string pathToOutputFile = "../../../output.txt";

            Lab_3 lab_3 = new Lab_3();


            lab_3.Run(pathToInputFile, pathToOutputFile);
        }
    }
}