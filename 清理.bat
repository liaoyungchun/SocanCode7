@echo off

set target=SocanCode

echo 正在清理。。。

del %target%\*.txt
del %target%\*.pdb
del %target%\*.manifest
del %target%\*.application
del %target%\*.vshost.*

del %target%\Config\System.xml
del %target%\Config\History.xml


echo 完成