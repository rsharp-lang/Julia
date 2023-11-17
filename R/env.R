#' try to get the julia runtime for load library in clr runtime
#' 
#' @return this function returns the library path to the julia runtime:
#' 
#' 1. windows:  path to the ``libjulia.dll`` library file,
#' 2. unix:  path to the ``libjulia.so`` library file. 
#' 
const __libjulia_env = function() {
    if ((Sys.info()[['sysname']]) == "Win32NT") {
        __libjulia_win_nt();
    } else {
        stop("not implements for linux.");
    }
}

#' Solve the julia runtime on windows platform
#' 
const __libjulia_win_nt = function() {
    for(dir in strsplit(Sys.getenv("PATH"), ";")) {
        if (file.exists(`${dir}/libjulia.dll`)) {
            return(`${dir}/libjulia.dll`);
        }
    }

    stop("The julia on your windows system could not be found!");
}