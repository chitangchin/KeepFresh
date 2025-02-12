# KeepFresh
 **AI-Powered Smart Fridge**  

## **Overview**  
This project is a smart fridge management system built with **C# and Microsoft Semantic Kernel**. It allows users to manage their food inventory using **natural language chat commands** powered by **OpenAI's GPT-4o**.  

## **MVP Features**  
- Add and remove food items using Natural Language commands  
- Track food quantities  
- Chat-based interaction using **Microsoft Semantic Kernel** and **OpenAI Chat Completion**  
- Secure API key management with **.NET User Secrets**  

## **Technologies Used**  
- **C# (.NET 8, Microsoft Semantic Kernel)**  
- **OpenAI GPT-4o** (for chat-based commands)  
- **Dependency Injection & Configuration Management**  
- **User Secrets for Secure API Key Storage**  

## **Getting Started**  

### **1. Clone the Repository**  
```bash
git clone https://github.com/chitangchin/KeepFresh.git
cd KeepFresh
```

### **2. Install Dependencies**  
```bash
dotnet restore
```

### **3. Securely Store API Keys**  
Use `.NET user-secrets` to store **OpenAI API keys**.  

```bash
dotnet user-secrets init
dotnet user-secrets set "OpenAI:ChatModelId" "gpt-4o"
dotnet user-secrets set "OpenAI:ApiKey" "your-openai-api-key"
```

## **Usage**  

### **1. Run the Fridge Chat Assistant**  
```bash
dotnet run
```

### **2. Interact with Your Smart Fridge**  

**Example Commands:**  
> "What food do I have?" → Lists all stored food items  
> "Add 5 apples." → Adds apples to the fridge  
> "Eat 2 bananas." → Decreases banana count  

## **Future Improvements**  
- Track food expiration dates in batches
- Improved natural language processing for complex food management requests
- Web or mobile interface for easier interaction  
