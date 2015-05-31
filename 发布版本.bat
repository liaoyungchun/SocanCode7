@echo off

call 清理.bat

echo 正在压缩。。。
set path=c:\program files\winrar
rar a -r SocanCode.rar %target% 使用指南.doc

echo 完成