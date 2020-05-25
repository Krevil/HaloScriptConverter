# HaloScriptConverter
Tool to automate the conversion of Script Expressions between Halo games

MCC Reach and Halo 2 script expressions have two main differences: Different opcodes, and an extra four bytes at the end of each expression. So to convert the bytes of a script from Reach to Halo 2, you need to remove those four bytes and change over the opcodes.

Currently, this tool is only capabale of removing the bytes. Future plans include converting opcodes and allowing conversion to and from other games in which Script Expressions are similar enough.

Check out the wip branch if you want to take a look at what I've been doing recently.
