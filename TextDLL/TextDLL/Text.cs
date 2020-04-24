using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDLL
{

    public interface IExecutableModule
    {
        void Execute(string[] _params);

        string About();

    }

    public class Text : IExecutableModule
    {
        public void Execute(string[] _params) { }

        public string About() { return ""; }
    }
}
