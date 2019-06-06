# RUN C++ IN VSCODE ON MAC

## How to run?

run the execute file directly like below:

```
./hello
```

## How to debug?

1. Setup tasks.json and launch.json as this [link](https://medium.com/gdplabs/build-and-debug-c-on-visual-studio-code-for-mac-77e05537105e)

2. Press F5

## Troubleshooting

1. Cannot debug in with error "Warning: Debuggee TargetArchitecture not detected, assuming x86_64".  [Answer]: run `xcode-select --install` in terminal after install xcode