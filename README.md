# Welcome to SimpleChess!

SimpleChess is a GUI Frontend for UCI Chess engines

# How does it look?

![Screenshot](./ChessGUI/images/screenshot.png)

# UCI WTF?

UCI, (Universal Chess Interface) an open communication protocol for chess engines to play games automatically, that is to communicate with other programs including Graphical User Interfaces. UCI was designed and developed by Rudolf Huber and Stefan Meyer-Kahlen [1] , and released in November 2000 [2] . It has, by-in-large, replaced the older Chess Engine Communication Protocol. (Wikipedia)

## What does that mean to you?

You can choose from a large list of UCI engines, and decide which to use, but keep always the same graphical user interface. Which is fine. The stockfish engine is the strongest open source chess engine though.

# Current state

SimpleChess is in very early development stage. So it is currently only possible to play white. 

# What you can already do with it?
- Play chess! Only with white, but it's playable.
- Load PGN files and view the match
- Undo moves
- Save and reload your match

# What you cannot do

- En-passant capturing 
- Choosing to which piece the pawn on the last row is being promoted

# Prerequisites

- Windows 
- Patience

# Known bugs

- Consolehost is not being closed after program close and remains as a zombie
- Sometimes the UCI communication is messed up and the board is in undefined state after

# Running

Grab a release from https://github.com/mpue/SimpleChess/releases and run SimpleChess.exe

