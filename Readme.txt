1. Open WebApp in browser. For well-known performance, Google Chromium browser is preferred.
2. Open DevelopperTools plugin for WebApp.
3. Make SSO authentification by choosing user for WebApp.
4. In Developper Tools go to Application -> Cookies, copy out AspNetCore cookies, which is chunked into 2 or 3 chunks.
5. Transfer copied cookie chunks into appsettings.json or into code in K6 performanceTest file.
6. Run PerformanceTests.