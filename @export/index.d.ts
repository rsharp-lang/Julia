// export R# source type define for javascript/typescript language
//
// package_source=Julia

declare namespace Julia {
   module _ {
      /**
      */
      function onLoad(): object;
   }
   /**
   */
   function __libjulia_env(): object;
   /**
   */
   function jl(script: any): object;
}
