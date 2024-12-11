# 環境說明
1. .NET SDK 8.0（下載並安裝 https://dotnet.microsoft.com/download）
2. Visual Studio 2022（確保已安裝 ASP.NET and web development 工作負載）

### 運行步驟
1. Clone 此專案到本地
2. 開啟 `WebApp.csproj` 檔案，使用 Visual Studio 2022打開專案。
3. 確保資料庫連線設定正確（未完成，可先跳過）。
4. 按下 F5 執行專案。


## MVC 資料流整理

1. **使用者發出請求**  
   瀏覽器向伺服器發送請求，由 Controller 接收。

2. **Controller 處理請求**  
   - Controller 呼叫 Model 獲取或修改所需的資料。
   - Model 負責資料的處理與業務邏輯。

3. **Model 返回資料**  
   - Model 將處理後的資料結果返回給 Controller。

4. **Controller 準備資料**  
   - Controller 將資料包裝成適合顯示的形式（例如 ViewModel），並傳遞給 View。

5. **View 渲染資料**  
   - View 接收來自 Controller 的資料，將其轉換為 HTML。
   - 伺服器將渲染後的 HTML 返回給用戶端瀏覽器。
