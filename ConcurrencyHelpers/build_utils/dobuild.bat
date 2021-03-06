@echo off
call dobuild_env.bat

call dobuild_single ConcurrencyHelpers 4.5 net45 src\ConcurrencyHelpers
call dobuild_single ConcurrencyHelpers 4.0 net40 src\ConcurrencyHelpers

call dobuild_nuget ConcurrencyHelpers src\ConcurrencyHelpers

call dobuild_simple CoroutinesLib.Shared 4.5 net45 src\CoroutinesLib.Shared
call dobuild_single CoroutinesLib 4.5 net45 src\CoroutinesLib

call dobuild_simple CoroutinesLib.Shared 4.0 net40 src\CoroutinesLib.Shared
call dobuild_single CoroutinesLib 4.0 net40 src\CoroutinesLib

call dobuild_nuget CoroutinesLib src\CoroutinesLib


call dobuild_single CoroutinesLib.TestHelpers 4.5 net45 utils\CoroutinesLib.TestHelpers
call dobuild_single CoroutinesLib.TestHelpers 4.0 net40 utils\CoroutinesLib.TestHelpers

call dobuild_nuget CoroutinesLib.TestHelpers utils\CoroutinesLib.TestHelpers

call dobuild_clean
pause
