# AdvancedCommandExecutor
Starts multiple processes with a single spintax command.

Usage:
```
AdvancedCommandExecutor.exe --perm "echo Hello {world|humans|coders} !!!"
```
Output: 

```
echo Hello world !!!
echo Hello humans !!!
echo Hello coders !!!

These commands will be executed. Do you want to start the processes.(y/n)

```

There are 2 possible commands: --sequential | --permutation

*Nested spintax can only be used for permutation option.*

Examples:
```
.\AdvancedCommandExecutor.exe --seq "echo {hello|world} {1|2} example"

echo hello 1 example
echo world 2 example
These commands will be executed. Do you want to start the processes.(y/n)
```
```
.\AdvancedCommandExecutor.exe --perm "echo {hello|world} {1|2} example"
echo hello 1 example
echo hello 2 example
echo world 1 example
echo world 2 example

These commands will be executed. Do you want to start the processes.(y/n)
```
