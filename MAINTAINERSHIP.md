codingteam.org.ru Maintainership
================================

Release
-------
To release a new version:
1. Update the copyright year in the `LICENSE.md`, if required.
2. Update the copyright year inside of the `<footer>` element of the `Codingteam.Site/Views/Shared/_Layout.cshtml`, if required.
3. Choose a new version according to [Semantic Versioning][semver]. It should consist of three numbers (i.e. `1.0.0`).
4. Make sure there's a properly formed version entry in the `CHANGELOG.md`.
5. Update the `<Version>` property in the `Codingteam.Site/Codingteam.Sire.fsproj` file.
6. Merge the aforementioned changes via a pull request.
7. Push a tag named `v<VERSION>` to GitHub.

The new release will be published and pushed to the Docker Hub automatically.

[semver]: https://semver.org/spec/v2.0.0.html
