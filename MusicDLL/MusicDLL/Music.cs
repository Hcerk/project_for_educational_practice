using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDLL
{
    public interface IExecutableModule
    {
        void Execute(string[] _params);

        string About();

    }

    public class Music : IExecutableModule
    {
        public void Execute(string[] _params) { }

        public string About() { return ""; }
    }
}
