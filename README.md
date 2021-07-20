# XF_FreeDiving
自己為了自由淺水閉氣練習的App順便練一下Xamarin.Forms

- 記錄使用者該次閉氣時間

- 使用FireBase作為紀錄**歷史紀錄**的方式

  

  



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



 