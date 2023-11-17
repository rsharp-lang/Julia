require(Julia);

str(Julia::jl([
    "sqrt(2.0)",
    "rand(1,3)",
    "rand(10,4)",
    "rand(3,1)",
    "ones(Int64, 2, 2)"
]));