using System;
using System.Xml.Linq;

namespace Lab3CSharp
{
    internal class Organization
    {
        private int _countOfEmployees;
        private string _name;

        public Organization(string name, int countOfEmpl)
        {
            _countOfEmployees = countOfEmpl;
            _name = name;
        }
        

        public virtual void Show()
        {
            Console.Write("  Organization name: " + _name +  "\n   Count of employees: " + _countOfEmployees);

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int CountOfEmployees
        {
            get { return _countOfEmployees; }
            set { _countOfEmployees = value; }
        }
    }
    internal class Factory
    {   
        private string _name;
        private int _countOfEmployees;
        private int _performance;
        public Factory(string name, int performance, int countOfEmployees)
        {
            _name = name;
            _countOfEmployees = countOfEmployees;
            Performance = performance;
        }
        public Factory()
        {
            _performance = 10;
            _countOfEmployees = 30;
            _name = " default";
        }

        public void Show()
        {

            Console.WriteLine("  Factory: " + _name + "   " + _performance + " Tons/hour");
        }
        public int CountOfEmployees
        {
            get { return _countOfEmployees; }
            set { _countOfEmployees = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Performance
        {
            get { return _performance; }
            set { _performance = value; }
        }
    }

    internal class Oil_Gas_Company : Organization
    {
        private string _gasType;
        private int _numberOfPipelines;
        private string _oilType;
        private int _numberOfWells;
        private Factory[] _factory;

        public Oil_Gas_Company(string name, int countOfEmpl, string oilType,string gasType, int numberOfWells, int numberOfPipelines,int factory)
            : base(name, countOfEmpl)
        {
            _oilType = oilType;
            _numberOfWells = numberOfWells;
            _gasType = gasType;
            _numberOfPipelines = numberOfPipelines;
             this._factory = new Factory [factory];
            for (int i =0; i < factory; i++)
            {
                _factory[i] = new Factory();
            }
        }
        public override void Show() 
        {
            base.Show();
            Console.Write("\n  Oil Type:  " + _oilType + "\n   Number Of Wells:  " + _numberOfWells + "\n   Gas Type:  " + _gasType + "\n   Number Of Pipelines:  " + _numberOfPipelines + "\n        ARRAY ::  \n");
            foreach (Factory a in _factory)
            {
               a.Show();
            }

        }
        public string OilType
        {
            get { return _oilType; }
            set { _oilType = value; }
        }

        public int NumberOfWells
        {
            get { return _numberOfWells; }
            set { _numberOfWells = value; }
        }

        public Factory[] pFactory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public string GasType
        {
            get { return _gasType; }
            set { _gasType = value; }
        }

        public int NumberOfPipelines
        {
            get { return _numberOfPipelines; }
            set { _numberOfPipelines = value; }
        }
    }
}

