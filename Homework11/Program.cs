using System.Collections.Generic;

namespace Homework11
{
    public enum Operation
    {
        Sum,
        Subtract,
        Multiply
    }
    public class OperationManager
    {
        private int _first;
        private int _second;
        public OperationManager(int first, int second)
        {
            _first = first;
            _second = second;
        }
        private int Sum()
        {
            return _first + _second;
        }
        private int Subtract()
        {
            return _first - _second;
        }
        private int Multiply()
        {
            return _first * _second;
        }
        public int Execute(Operation operation)
        {
            switch (operation)
            {
                case Operation.Sum:
                    return Sum();
                case Operation.Subtract:
                    return Subtract();
                case Operation.Multiply:
                    return Multiply();
                default:
                    return -1; //just to simulate
            }
        }
    }

    //Implement functionality
    public class ExecutionManager
    {
        private int _first;
        private int _second;

        public Dictionary<Operation, Func<int>> FuncExecute { get; set; }
        //Add delegates for sum, substrat and multiply here
        public ExecutionManager(int first, int second)
        {
            _first = first;
            _second = second;
            FuncExecute = new Dictionary<Operation, Func<int>>()
        {
            { Operation.Sum, () => _first + _second },
            { Operation.Subtract, () => _first - _second },
            { Operation.Multiply, () => _first * _second }
        };
        }

        /* public void PopulateFunctions(//pass delegates and register)
         {

         }
         public void PrepareExecution()
         {
             //fill dictionary here
         }
     } */

        class Program
        {
            static void Main(string[] args)
            {
                var opManager = new OperationManager(20, 10);
                var result = opManager.Execute(Operation.Sum);
                Console.WriteLine($"The result of the operation is {result}");
                Console.ReadKey();
            }
        }
    }
}
