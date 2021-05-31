Microsoft a publié récemment beaucoup d’aperçus sur .Net 6. Je profite de cette preview 4 pour vous montrer une fonctionnalité qui permet d’intégrer du code « Blazor » dans un projet « WPF ».

Dans cet article, il ne s’agit en aucun cas, de comparer ou de critiquer la technologie en tant que développement, mais bien juste une exploration, d’une des possibilités qu’offre la dernière mise à jour de .Net 6 preview 4.

Le contrôle BlazorWebView est essentiel, car ce dernier permet l’utilisation des composants Blazor à l’intérieur du WPF. 

Vous trouverez un projet simpliste sur Github qui montre l’utilisation d’une application « hybride ». Il s’agit d’une petite application de gestion de « livres » avec la possibilité de stocker des données en bases (CRUD) en utilisant Entity Framework et Sqlite. 

Conditions minimales :
Visual Studio 16.10
Installer le SDK .Net 6 preview 4 : https://dotnet.microsoft.com/download/dotnet/6.0
	

Références …
https://visualstudiomagazine.com/articles/2021/04/09/blazorwebview.aspx?admgarea=features
https://github.com/edandersen/blazor-desktop-crossplatform-sample

