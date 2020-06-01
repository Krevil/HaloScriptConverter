# HaloScriptConverter
Tool to automate the conversion of Script Expressions between Halo games

MCC Reach and Halo 2 script expressions have two main differences: Different opcodes, and an extra four bytes at the end of each expression. So to convert the bytes of a script from Reach to Halo 2, you need to remove those four bytes and change over the opcodes.

This is the WIP branch. This version has some opcode conversions, but only a choice few I've required rather than the whole several thousand opcodes there are in each game.
