﻿using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/5643958569";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/4167225361";
    
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/7724392377";
     public static string hedieuhanh="ios";
   

#endif

#if UNITY_ANDROID


                         public static string adsInIDGameOver = "ca-app-pub-5148482490300491/5643958569";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/4167225361";

    public static string adsInIDBanner = "ca-app-pub-5148482490300491/7724392377";
                         public static string hedieuhanh = "android";

#endif

}
