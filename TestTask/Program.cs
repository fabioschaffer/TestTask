using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask {
    public class Program {
        static async Task Main(string[] args) {

            //Copiado de https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/

            Coffee cup = new Coffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (breakfastTasks.Count > 0) {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask) {
                    Console.WriteLine("eggs are ready");
                } else if (finishedTask == baconTask) {
                    Console.WriteLine("bacon is ready");
                } else if (finishedTask == toastTask) {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = new Juice();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task<Egg> FryEggsAsync(int howMany) {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number) {
            var toast = await ToastBreadAsync(number);
            return toast;
        }

        private static async Task<Toast> ToastBreadAsync(int slices) {
            for (int slice = 0; slice < slices; slice++) {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices) {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++) {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        


    }

    public class Coffee { }
    public class Egg { }
    public class Bacon { }
    public class Toast { }
    public class Juice { }
}