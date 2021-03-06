﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ClsThaoTac  {

    public static string CoverTimeToString(int mTime)
    {
        string stTime = "";
        int timeN = mTime / 60;
        int timeD = mTime % 60;
        if (timeD >= 10)
        {
            stTime = "" + timeN + ":" + timeD;
        }
        else
        {
            stTime = "" + timeN + ":0" + timeD;
        }
        return stTime;
    }

    public static List<PhepToan> ChuanHoaDaTa(int khoang, List<PhepToan> lst)
    {
        if (khoang > lst.Count - 1)
        {
            return lst;
        }
        else
        {
            List<PhepToan> lstTmg = new List<PhepToan>();
            while (lstTmg.Count < khoang)
            {
                int chon = UnityEngine.Random.Range(0, lst.Count);
                bool ok = false;
                for (int i = 0; i < lstTmg.Count; i++)
                {
                    if (lst[chon].Ketqua == lstTmg[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    lstTmg.Add(lst[chon]);
                }
            }
            return lstTmg;
        }
    }

    public static List<PhepToan> FakeData(int dau, int cuoi)
    {
        List<PhepToan> lstTam = new List<PhepToan>();
        for (int i = dau; i <= cuoi; i++)
        {
            PhepToan pt = new PhepToan("" + i, i, "number");
            lstTam.Add(pt);
        }
        return lstTam;
        
    }

    public static PhepToan getCongThuc(PhepToan giatri)
    {
        string ct = giatri.Congthuc.Trim();
        string[] items = ct.Split(new Char[] { '-', '+', 'x', ':' });
        string tm = "";
        if (ct.Contains("+"))
        {
            tm = ClsLanguage.doTong();
        }else if(ct.Contains("-"))
        {
            tm = ClsLanguage.doHieu();
        }
        else if (ct.Contains("x"))
        {
            tm = ClsLanguage.doNhan();
        }
        else if (ct.Contains(":"))
        {
            tm = ClsLanguage.doChia();
        }

        if (tm.Trim().Equals(""))
        {
            return new PhepToan("" + giatri.Congthuc, giatri.Ketqua, "number");
        }
        else
        {
            return new PhepToan(tm + items[0] + ClsLanguage.doAnd() + items[1], giatri.Ketqua, "number");
        }
    }
    public static string getTimeCongThuc(string giacu)
    {
        string[] mang = giacu.Split(new Char[] { 'h', 'k' });
        string ptmoi = "";
        string txtTime = "";
        string txtPhut = "";
        int gio = int.Parse(mang[0]);
        int phut = int.Parse(mang[1]);
        switch (gio)
        {
            case 1:
                txtTime = "one";
                break;
            case 2:
                txtTime = "two";
                break;
            case 3:
                txtTime = "three";
                break;
            case 4:
                txtTime = "four";
                break;
            case 5:
                txtTime = "five";
                break;
            case 6:
                txtTime = "six";
                break;
            case 7:
                txtTime = "seven";
                break;
            case 8:
                txtTime = "eight";
                break;
            case 9:
                txtTime = "nine";
                break;
            case 10:
                txtTime = "ten";
                break;
            case 11:
                txtTime = "eleven";
                break;
            case 12:
                txtTime = "twelve";
                break;
        }


        switch (phut)
        {
            case 5:
                txtPhut = "five";
                break;
            case 10:
                txtPhut = "ten";
                break;
            case 15:
                txtPhut = "fifteen";
                break;
            case 20:
                txtPhut = "twenty";
                break;
            case 25:
                txtPhut = "twenty-five";
                break;
            case 30:
                txtPhut = "twenty-five";
                break;
            case 35:
                txtPhut = "thirty-five";
                break;
            case 40:
                txtPhut = "forty";
                break;
            case 45:
                txtPhut = "forty-five";
                break;
            case 50:
                txtPhut = "fifty";
                break;
            case 55:
                txtPhut = "fifty-five";
                break;
        }

        if (giacu.Contains("h"))
        {
            if (GameController.instance.tienganh)
            {
                if (int.Parse(mang[1]) == 0)
                {
                    ptmoi = txtTime + " o'clock";
                }
                else
                {
                    if (int.Parse(mang[1]) == 15)
                    {
                        ptmoi = "a quarter past " + txtTime;
                    }
                    else if (int.Parse(mang[1]) == 30)
                    {
                        ptmoi = "half past " + txtTime;
                    }
                    else
                    {
                        ptmoi = txtPhut + " past " + txtTime;
                    }
                }
            }
            else
            {
                if (int.Parse(mang[1]) == 0)
                {
                    ptmoi = mang[0] + " giờ";
                }
                else
                {
                    ptmoi = mang[0] + " giờ " + mang[1] + " phút";
                }
            }
        }
        else
        {
            if (GameController.instance.tienganh)
            {
                if (int.Parse(mang[1]) != 0)
                {
                    if (int.Parse(mang[1]) == 15)
                    {
                        ptmoi = "a quarter to " + txtTime;
                    }
                    else
                    {
                        ptmoi = txtPhut+ " to " + txtTime;
                    }
                }
            }
            else
            {
                ptmoi = mang[0] + " giờ kém " + mang[1] + " phút";
            }
        }
        return ptmoi;
    }


    public static PhepToan getPhepToan(PhepToan giatri, List<PhepToan> lst)
    {
        List<PhepToan> tmg = new List<PhepToan>();
        foreach (PhepToan item in lst)
        {
            if (item.Congthuc.Equals(giatri.Congthuc))
                continue;
            if (item.Ketqua == giatri.Ketqua)
            {
                tmg.Add(item);
            }
        }

        if (tmg.Count > 0)
        {
            int chon = UnityEngine.Random.Range(0, tmg.Count);
            return new PhepToan(tmg[chon].Congthuc, tmg[chon].Ketqua, "number");
        }
        else
        {
            return new PhepToan("" + giatri.Ketqua, giatri.Ketqua, "number");
        }
    }

    }

