using AsyncAwait;

//Console.WriteLine("--------Class1--------");
//await Class1.Method1();
//Class1.Method2();

//Console.WriteLine("--------Class2--------");
//Class2.callMethod();
//Console.ReadKey();

Task task = new Task(FileProcess.CallMethod);
task.Start();
task.Wait();
Console.ReadLine();
Console.ReadLine();