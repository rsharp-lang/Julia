// export R# package module type define for javascript/typescript language
//
//    imports ".interop" from "Julia";
//
// ref=Julia.Interop@Julia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

/**
*/
declare namespace .interop {
   /**
     * @param env default value Is ``null``.
   */
   function jl_eval_string(expr: any, env?: object): any;
   /**
     * @param code default value Is ``0``.
   */
   function jl_exit(code?: object): ;
   /**
   */
   function jl_gc(): ;
   /**
   */
   function start_jl(libjulia: string): any;
}
