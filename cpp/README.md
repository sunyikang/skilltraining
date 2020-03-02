# RUN C++ IN VSCODE ON MAC

## How to run/debug from shortcuts?

Let's say we have a cpp file `cppdatatype.cpp`, we are developing it and need to build and run this file for many times.  So we want to use the shortcuts to complete it.  
 
1) Change `tasks.json` file to point to this file, then can use `Shift+Cmd+B` shortcut to build this file.    Note: Remember to add `-g` in the command, that turn on debug information.

```
{
    "version": "2.0.0",
    "tasks": [
      {
        "label": "Build with Clang",
        "type": "shell",
        "command": "clang++",
        "args": [
          "-std=c++17",
          "-stdlib=libc++",
          "sandbox/cppdatatype.cpp",
          "-o",
          "sandbox/cppdatatype.out",
          "-g"
        ],
        "group": {
          "kind": "build",
          "isDefault": true
        }
      }
    ]
}
```

2) Change `launch.json` file to point to the out file.  Then you can use `F5` shortcut to debug/run this file.

```
{
    "version": "0.2.0",
    "configurations": [
      {
        "name": "Launch",
        "type": "lldb",
        "request": "launch",
        "program": "${workspaceFolder}/sandbox/cppdatatype.out",
        "args": [],
        "cwd": "${workspaceFolder}"
      }
    ]
}

```

## How to run from command line?

In practice, there are many exam can run just in one cpp file, and it will be bore to config the task.json file each time.  Alternatively, compile and link a cpp file via command line would be economical.  So here we go.

1) compile only (add -c if want to create hello.o file)

```
cd sandbox
clang++ hello.cpp 
clang++ hello.cpp -c
```

2) compile and link to an executive file, and run it.

```
cd sandbox
clang++ hello.cpp -o hello.out
./hello.out
```

3) option to add for features in C++17

```
clang++ cppdatatype.cpp -o cppdatatype.out --std=c++17
```

## Troubleshooting

1) Cannot stop on breakpoint when debugging! 

    a) Check `DEBUG CONSOLE` bar. If it has error message `Warning: Debuggee TargetArchitecture not detected, assuming x86_64`, then try to run `xcode-select --install` in terminal (if haven't install xcode, install it firstly).

    b) Also see [VSCode, MacOS Catalina - doesn't stop on breakpoints on C/C++ debug](https://stackoverflow.com/questions/58329611/vscode-macos-catalina-doesnt-stop-on-breakpoints-on-c-c-debug), which point to a known issue when upgrading to macOS Catalina.  See [Can't debug on macOS Catalina (LLDB)](https://github.com/microsoft/vscode-cpptools/issues/3829).  Recommand to i) install `CodeLLDB` extension in VSCode; ii) change the `launch.json` file according to this [README](https://github.com/vadimcn/vscode-lldb).

    c) For debugging, reference to [old link](https://medium.com/gdplabs/build-and-debug-c-on-visual-studio-code-for-mac-77e05537105e) and [new link](https://code.visualstudio.com/docs/cpp/config-clang-mac).

2) `PROBLEMS` bar has 2 errors, one says `#include errors detected`!

    Follow [Using Clang in Visual Studio Code](https://code.visualstudio.com/docs/cpp/config-clang-mac) to add `c_cpp_properties.json` file, which specify the `compilerPath` and `includePath`.