# XF_FreeDiving
自己為了自由淺水閉氣練習的App順便練一下Xamarin.Forms

- 記錄使用者該次閉氣時間

- 使用FireBase作為紀錄**歷史紀錄**的方式

- 使用 Web Authenticator 進行登入驗證

    



# 使用的套件

1. sqlite-net-pcl
   1. UWP 路徑會在 C:\Users\[YourUserName]\AppData\Local\Packages\
      C:\Users\xxxxx\AppData\Local\Packages\fcdc2c73-f1fd-424c-9b98-9632fab5d334_75cr2b68sm664\LocalState\FreeDivingSQLite.db3
2. Xamarin.Forms.PancakeView
3. SkiaSharp (尚未使用)
4. Resizetizer.NT (讀取圖片用)
5. Xamarin.Forms 4.8
   1. 此專案是使用Shell 樣板建立的
   2. [CollectionView](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/user-interface/collectionview/)
      1. 成功使用SelectedItem可以找到選到的項目
   3. ListView
   4. [Frame](https://devblogs.microsoft.com/xamarin/xamarinforms-4-8-gradients-brushes/)
   5. [SwipeView](https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/user-interface/swipeview)



# 預計實作的項目

- [ ] 依照自己製作的Layout建立畫面

  - [ ] 使用者
    - [x] 2020/11/03 先固定設定兩個使用者可以選擇即可
    - [ ] 讓  `XamarinForms` 讀取使用者上傳的圖片
    
  - [x] 紀錄種類

  - [x] 計時

  - [x] 歷次紀錄

  - [ ] 圖表(列出選取到的使用者歷次紀錄曲線圖)

    - [ ] 使用 `MVVM Data Binding` 的方式顯示資料
    - [ ] 使用 DI 注入取得資料 
    
    

- [ ] 整理應用程式的Style為可以共用

- [x] 使用CollectionView

  - [x] 建立使用者清單
  - [x] 增加 2:00 & 2:30 & 3:00 .... 的選項

- [ ] 可自行新增使用者列表

  - [ ] 建立使用者編輯畫面

- [ ] 當選擇到非碼表的選項增加 上下的箭頭 可以微調時間(5s)

- [x] 刪除功能

  - [ ] 使用SwipeView

  

## 2020/11/01 預計實作Layout

![FreeDiving_Layout](https://raw.githubusercontent.com/FocacciaSyin/XF_FreeDiving/master/Layout/iPhone%20X%2C%20XS%2C%2011%20Pro%20%E2%80%93%201.png)



#  Web Authenticator

## 實作紀錄

> 參考資料：
>
> - [Xamarin.Essentials： Web Authenticator - Xamarin | Microsoft Docs](https://docs.microsoft.com/zh-tw/xamarin/essentials/web-authenticator?tabs=android)
> - https://youtu.be/g8oh-dvfW1k

### Azure 

1. 透過 WebAPI 當作中介的登入跳板

2. 把WebAPI 架在 Azure 上(使用免費空間)
   1. 發佈 - 建立一個新的 AppService 執行個體 XFFreeDivingAPI-Essential-WebAuth
   2. 使用 GitHub Actions (注意! 現在先跳過API管理這個項目，多了一個*服務主體秘密* 會發不過，這還要再研究不是現在要注意的東西)
   3. 實作 MobileAuthController.cs
      1. 注意 ` https://localhost:5001/mobileauth/Google`  Google G 要是大寫
   
3. App 端

   1. 使用Prism所以功能都還是依照MVVM框架比較順

   2. 參考LoginPageViewModel

   3. Command參考範例

      ```c#
      private DelegateCommand _navigateCommand;
      
      public DelegateCommand GoogleLoginCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(GoogleLogin));
      
      private async void GoogleLogin()
      {
      	//to Somthing
      
      }
      ```

   4. 取得使用者資訊

      > https://www.googleapis.com/oauth2/v3/userinfo?access_token={0}

   5. 透過Essentials 寫入 類似 Cookie的東西

      ```c#
      Settings.AccessToken = authToken;
      
      
      ================================================================================
          public static class Settings
          {
              /// <summary>
              /// 使用者Token
              /// </summary>
              /// <value>
              /// The access token.
              /// </value>
              public static string AccessToken
              {
                  get
                  {
                      return Preferences.Get("accestoken", SettingsDefault);
                  }
                  set
                  {
                      Preferences.Set("accestoken", value);
                  }
              }
          }
      ```