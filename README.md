# Uranus

Thread based library for asynchronous executions in .NET Standard.

## Getting Started

Just run in your command line:

```
git clone https://github.com/bruno303/Uranus
```

### Prerequisites

* .NET Standard 2.0

### API

**ActionUranusThread**: Class in charge of performing asynchronous Actions with no input parameters.

Example:
```
var uranus = new Uranus.Source.Threads.ActionUranusThread();

uranus.ThreadMethod = () => Console.WriteLine("Hello World!");

uranus.Execute();
```

**ParameterizedActionUranusThread**: Class in charge of performing asynchronous Actions with one input parameter.

Example:
```
var uranus = new Uranus.Source.Threads.ParameterizedActionUranusThread<string>();
var parameter = "Hello World!";

uranus.ThreadMethod = msg => Console.WriteLine(msg);

uranus.Execute(parameter);
```

**FuncUranusThread**: Class in charge of performing asynchronous Func with no input parameters.

Example:
```
var uranus = new Uranus.Source.Threads.FuncUranusThread<string>();

uranus.ThreadMethod = () => "Hello World!";

uranus.AfterExecution += (sender, e) =>
{
    if (e.HasError)
    {
        Console.Error.WriteLine(e.Error.Message);
    }
    else
    {
        // The result of ThreadMethod will be available in e.Result
        Console.WriteLine(e.Result);
    }
};

uranus.Execute();
```

**ParameterizedFuncUranusThread**: Class in charge of performing asynchronous Func with one input parameter.

Example:
```
var uranus = new Uranus.Source.Threads.ParameterizedFuncUranusThread<int, string>();
var parameter = 30;

uranus.ThreadMethod = num => $"Hello World with number {num}";

uranus.AfterExecution += (sender, e) =>
{
    if (e.HasError)
    {
        Console.Error.WriteLine(e.Error.Message);
    }
    else
    {
        // The result of ThreadMethod will be available in e.Result
        Console.WriteLine(e.Result);
    }
};

uranus.Execute(parameter);
```

## Authors

* **Bruno Oliveira** - [Github](https://github.com/bruno303)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
