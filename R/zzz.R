imports ".interop" from "Julia";

const .onLoad = function() {
    .interop::start_jl(libjulia = __libjulia_env());

    cat("
               _
   _       _ _(_)_     |  Documentation: https://docs.julialang.org
  (_)     | (_) (_)    |
   _ _   _| |_  __ _   |  Type '?' for help, ']?' for Pkg help.
  | | | | | | |/ _` |  |
  | | |_| | | | (_| |  |  Version 1.9.4 (2023-11-14)
 _/ |\__'_|_|_|\__'_|  |  Official https://julialang.org/ release
|__/                   |
    
    \n");
}