# Changelog

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project currently adheres to [Semantic
Versioning](https://semver.org/spec/v2.0.0.html).

This file only documents changes in the site engine, not any changes in the
hosting infrastructure.

## [1.1.0] - 2023-07-18
### Removed
- There's no longer a **Resources** page; all the resources are now listed on the main page.

## [1.0.2] - 2021-02-22
### Fixed
- Pages now have proper titles

## [1.0.1] - 2020-10-11
### Added
- A link to our Matrix room

## [1.0.0] - 2020-08-09
### Changed
- Updated to .NET Core 3.1
- The application is now delivered as a Docker image

## [0.7.7] - 2019-12-26
### Changed
- A link to LogList (which has been moved to a new domain)

## [0.7.6] - 2019-05-12
### Changed
- Update to .NET Core 2.2

## [0.7.5] - 2018-02-24
### Changed
- The copyright year

## [0.7.4] - 2017-07-09
### Changed
- Update to .NET Core 1.0.4

## [0.7.3] - 2017-06-18
### Changed
- A link to LogList

## [0.7.2] - 2017-01-28
### Changed
- A link to the Telegram group

## [0.7.1] - 2017-01-02
### Fixed
- A note of the date range containing in the log archive

## [0.7.0] - 2016-12-31
### Added
- A link to the log archive (preserved from 0xd34df00d.me)

## [0.6.4] - 2016-12-10
### Changed
- Default timezone offset for the external log server

## [0.6.3] - 2016-11-13
### Added
- A backup XMPP conference link

## [0.6.2] - 2016-11-08
### Added
- Codingteam logo

## [0.6.1] - 2016-10-25
### Added
- A link to our Telegram group
- A copyright notice in the site footer

## [0.6.0] - 2016-10-19
### Added
- A configuration to change the external log location
  ([#39](https://github.com/codingteam/codingteam.org.ru/issues/39)) and
  timezone

### Changed
- font-awesome icons are now used as bullets in the list on the Resources page

## [0.5.0] - 2016-10-17
The application has been rewritten in F#, using ASP.NET Core, after the
maintainers have been unable to build and redeploy the previous version (see
[#32](https://github.com/codingteam/codingteam.org.ru/issues/32) and
[#34](https://github.com/codingteam/codingteam.org.ru/issues/34)).

## [0.4.3] - 2015-04-14
### Changed
- Small textual fix

## [0.4.2] - 2015-03-09
### Fixed
- The favicon is now properly linked from the pages

## [0.4.1] - 2015-03-09
### Added
- Resource list

### Changed
- A new PNG favicon instead of an old ICO one

### Removed
- Google Analytics

## [0.4.0] - 2015-03-09
The application has been rewritten in Haskell, using Yesod web framework.

### Changed
- There's now an `iframe` with logs instead of a redirect
- The application now requires a database, with a structure to store the
  registered users.

  _(Notably, there's no way to either register or access the database in any
  way outside the application tests.)_

## [0.3.0] - 2014-02-09
### Fixed
- Time zone handling in the redirect endpoint
  ([#3](https://github.com/codingteam/codingteam.org.ru/issues/3))

## [0.2.0] - 2014-02-09
### Added
- `/version` endpoint

## [0.1.0] - 2014-02-02
Initial version of the application, written in Scala using Spray framework.

### Added
- Redirect to the actual logs hosted on 0xd34df00d.me

[0.1.0]: https://github.com/codingteam/codingteam.org.ru/releases/tag/v0.1
[0.2.0]: https://github.com/codingteam/codingteam.org.ru/compare/v0.1...v0.2
[0.3.0]: https://github.com/codingteam/codingteam.org.ru/compare/v0.2...0.3
[0.4.0]: https://github.com/codingteam/codingteam.org.ru/compare/0.3...0.4
[0.4.1]: https://github.com/codingteam/codingteam.org.ru/compare/0.4...0.4.1
[0.4.2]: https://github.com/codingteam/codingteam.org.ru/compare/0.4.1...0.4.2
[0.4.3]: https://github.com/codingteam/codingteam.org.ru/compare/0.4.2...0.4.3
[0.5.0]: https://github.com/codingteam/codingteam.org.ru/compare/0.4.3...0.5.0
[0.6.0]: https://github.com/codingteam/codingteam.org.ru/compare/0.5.0...v0.6.0
[0.6.1]: https://github.com/codingteam/codingteam.org.ru/compare/v0.6.0...0.6.1
[0.6.2]: https://github.com/codingteam/codingteam.org.ru/compare/0.6.1...0.6.2
[0.6.3]: https://github.com/codingteam/codingteam.org.ru/compare/0.6.2...0.6.3
[0.6.4]: https://github.com/codingteam/codingteam.org.ru/compare/0.6.3...0.6.4
[0.7.0]: https://github.com/codingteam/codingteam.org.ru/compare/0.6.4...0.7.0
[0.7.1]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.0...0.7.1
[0.7.2]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.1...0.7.2
[0.7.3]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.2...0.7.3
[0.7.4]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.3...0.7.4
[0.7.5]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.4...0.7.5
[0.7.6]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.5...0.7.6
[0.7.7]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.6...0.7.7
[1.0.0]: https://github.com/codingteam/codingteam.org.ru/compare/0.7.7...1.0.0
[1.0.1]: https://github.com/codingteam/codingteam.org.ru/compare/1.0.0...1.0.1
[1.0.2]: https://github.com/codingteam/codingteam.org.ru/compare/1.0.1...v1.0.2
[1.1.0]: https://github.com/codingteam/codingteam.org.ru/compare/v1.0.2...v1.1.0
[Unreleased]: https://github.com/codingteam/codingteam.org.ru/compare/v1.1.0...HEAD
