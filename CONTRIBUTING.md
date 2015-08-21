# How to contribute

NotificationsExtensions is written by Microsoft, but we're glad to have you help contribute to the library! There are three ways to contribute...

- Report bugs (open a new issue)
- Request features (open a new issue)
- Fix bugs/add features (open a pull request)


## Reporting Bugs

If you find a bug in the library, go to the Issues section of the GitHub, and create a new issue. Label it as "bug".


## Requesting Features

Have a suggestion of how the library could be improved? A new method? New types? Whatever it is, go to the Issues section of the GitHub, create a new issue, and label it "request".


## Fixing Bugs / Adding Features (pull requests)

If you'd like to fix something in the code, or add new features to the code, here's the requirements...

1. Your modification needs to fit within the goals listed on the Wiki's home page
2. You need to add or modify tests to make sure your change is thoroughly tested (the test projects use shared code so that there can be a NETCore test project and a Portable test project, make sure your test works in both)
3. Run all the tests (including your new ones) and ensure they all pass
4. Follow the coding style of the original source code
5. If your changes affect the public API, make sure all summaries on classes/methods/properties are properly updated so that users of the API can understand what the API does via IntelliSense
6. DO NOT BREAK THE PUBLIC API SURFACE, we do not want to break the API for existing devs using the library. Over time we might have to depreciate things, but in general we should try to ensure that devs can simply update the library without worrying that their code won't compile after the update.

I will still have the final say deciding which requests get added. If you're worried I might reject a request, talk to me before hand. If you're proposing adding a new property, for example, I might disagree that the property should be added. Thus, it would save your time if you simply asked me first, before coding it up. A good way to ask me would be to open a new feature request issue, state what your feature would do, state that you're willing to code it up, and ask me if I'll accept the pull request. Then you can code it and send the pull request.
