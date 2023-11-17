
#' try to get the julia runtime for load library in clr runtime
#' 
#' @return this function returns the library path to the julia runtime:
#' 
#' 1. windows:  path to the ``libjulia.dll`` library file,
#' 2. unix:  path to the ``libjulia.so`` library file. 
#' 
const __libjulia_env = function() {

}