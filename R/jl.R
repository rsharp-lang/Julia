#' Execute the julia expression and evaluated as R# value
#' 
const jl = function(script) {
    .interop::jl_eval_string(script);
}