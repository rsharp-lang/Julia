imports ".interop" from "Julia";

const .onLoad = function() {
    .interop::start_jl(libjulia = __libjulia_env());
}