using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Playground
{
	class Program
	{
		static void Main(string[] args)
		{
			Observable.Interval(TimeSpan.FromSeconds(5)).Subscribe(_ => Console.WriteLine("Triggered"));

			Console.ReadLine();
		}
	}
}
