# MVC 資料流整理

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
