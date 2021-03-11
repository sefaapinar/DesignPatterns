using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgortihm Algortihm;

            Console.WriteLine("Mans");
            Algortihm = new MensScoringAlgorithm();
            Console.WriteLine(Algortihm.GenerateScore(7,new TimeSpan(0,2,14)));

            
            Console.WriteLine("Voman");
            Algortihm = new WomanScoringAlgorithm();
            Console.WriteLine(Algortihm.GenerateScore(7, new TimeSpan(0, 2, 0)));

          
            Console.WriteLine("Kids");
            Algortihm = new KidsScoringAlgorithm();
            Console.WriteLine(Algortihm.GenerateScore(7, new TimeSpan(0, 1, 54)));

            Console.ReadLine();
        }
    }

     abstract class ScoringAlgortihm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScor(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);

        }

        public abstract int CalculateOverallScore(int score, int reduction);
      
        

        public abstract int CalculateReduction(TimeSpan time);
        

       public abstract int CalculateBaseScor(int hits);
       
        
    }

    class MensScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScor(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return(int) time.TotalSeconds / 5;
        }
    }
    class WomanScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScor(int hits)
        {
            return hits * 120;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }

    class KidsScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScor(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
