---
theme: ./mathema-2023
defaults:
  layout: "default-with-footer"
title: 'Wir testen. Aber testen wir auch gut genug?'
occasion: "CodeBuzz 2025"
occasionLogoUrl: "./images/logo-codebuzz.png"
company: "MATHEMA GmbH"
presenter: "Patrick Drechsler"
contact: "patrick.drechsler@mathema.de"
info: |
  ## Mutation testing
canvasWidth: 980
layout: cover
transition: slide-left
mdc: true
download: true

src: ./pages/00-title.md
---

---
src: ./pages/01-intro.md
---

---

## Let's talk about "Metrics" ...

<v-clicks>

- <span v-mark.strike-through.gray="3">"If you can't measure it, you can't manage it"</span> - *attributed* to W. Edwards Deming 🤔
- "**It is wrong** to suppose that if you can't measure it, you can't manage it - **a costly myth**." - the actual quote by W. Edwards Deming,  [The New Economics (1993)](https://deming.org/myth-if-you-cant-measure-it-you-cant-manage-it/) 👀
</v-clicks>

<br/>

<v-clicks at="4">

- [**Campbell's Law**](https://www.nngroup.com/articles/campbells-law) states that **the more important a metric is** in social decision making, the **more likely it is to be manipulated**.
- **Goodhart's Law** states that **"When a measure becomes a target, it ceases to be a good measure."**

</v-clicks>

<img
  class="absolute bottom-15 right-90 h-35"
  src="/images/metrics-charts.png"
/>

---

## Test coverage

<v-clicks>

- 🎓 defines the percentage of covered code
- ✅ 100% test coverage means, every line of code is executed at least once
- ⚠️ 100% test coverage **does not mean that every scenario / use-case is covered**

</v-clicks>

---

## Is Test coverage a "good metric"?

- not every line of code needs to be tested
- BUT: having no tests is obviously also not a good idea
- anything above 60% is a good baseline (but, "it depends")
- test coverage does not tell us anything about the **quality** of the tests

<img
  class="absolute bottom-20 left-5 w-80"
  src="/images/meme-failing-tests-1.gif"
/>
<img
  class="absolute bottom-15 left-87 w-70"
  src="/images/meme-failing-tests-2.gif"
/>
<img
  class="absolute bottom-20 right-5 w-80"
  src="/images/meme-failing-tests-3.gif"
/>

---
layout: image
image: /images/whos-testing-the-tests-meme.jpg
backgroundSize: contain
---

---

## What is mutation testing?

[https://stryker-mutator.io/docs/](https://stryker-mutator.io/docs/)

<v-clicks>

- Mutation testing **introduces changes to your code**, then runs your unit tests against **the changed code**.
- the "change" is called a **mutant**
- If our test suite is ok for a "mutant:" Ups, we missed something

</v-clicks>

<img v-click='[2]'
  class="absolute bottom-10 right-85 w-50"
  style="border-radius: 25%"
  src="/images/mutant-monster3.jpg"
/>

---
layout: two-cols-header
clicks: 2
---

### Hello-World Example

::left::

Production code:

```cs
public string DoMagic(int i) => i < 18 ? "child" : "adult"
```

<div v-click>

- `dotnet stryker`
- it creates a mutant replacing `<` with `<=`

```cs
public string DoMagic(int i) => i <= 18 ? "child" : "adult"
```

</div>

<arrow v-click="[1]" x1="312" y1="110" x2="312" y2="140" color="red" width="2" arrowSize="1" />
<arrow v-click="[1]" x1="315" y1="310" x2="315" y2="280" color="red" width="2" arrowSize="1" />

<div v-click="[2]">

- The mutant "survived"
- The mutant did not provoke a test failure!
- ⚠️ Our test suite might not be good enough! ⚠️

</div>

::right::

Test suite (**100% code coverage!**):

```cs
[Theory]
[InlineData(10, "child")]
[InlineData(20, "adult")]
public void DoMagic_works(int input, string expected)
{
  DoMagic(input).Should().Be(expected)
}
```

<img
  v-click="[2]"
  class="absolute bottom-5 right-75 h-60"
  src="/images/mutant-monster2.jpg"
/>

<style>
.col-bottom {
  align-self: end;
  grid-area: 3 / 1 / 4 / 3; /* Adjust this to correctly place the bottom area */
}
.two-cols-header {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: auto 1fr auto;
  column-gap: 20px; /* Adjust the gap size as needed */
}
</style>

---
layout: image-right
image: "/images/cute-zombie4.jpg"
---

## Mutations

Let's have a look at mutations: [https://stryker-mutator.io/docs/stryker-net/mutations/](https://stryker-mutator.io/docs/stryker-net/mutations/)

Most mutations are language agnostic

Some are optimized for .NET:

- [Initializers](https://stryker-mutator.io/docs/stryker-net/mutations/#initialization-initializer)
- [Removal](https://stryker-mutator.io/docs/stryker-net/mutations/#removal-mutators-statement-block)
- [Linq](https://stryker-mutator.io/docs/stryker-net/mutations/#linq-methods-linq)
- [Null-coalescing Operators](https://stryker-mutator.io/docs/stryker-net/mutations/#null-coalescing-operators-nullcoalescing)

---

## Isn't this slow?

<v-clicks>

- Short answer: YES
- BUT: **These frameworks have smart heuristics for short circuiting**
- CI: Don't include this in normal commits
- CI: use "Nightly", or local (for **exploratory analysis**)
- Google uses Mutation Testing on really large projects: <https://research.google/pubs/practical-mutation-testing-at-scale-a-view-from-google/>
  - "[...] a codebase of **two billion lines of code** and more than **150,000,000 tests**"
  - "[...] used by more than **24,000 developers** on more than **1,000 projects**"
  - It is still slow, but not as slow as you might think
  - 🎧 SE Radio 632: Goran Petrovic on Mutation Testing at Google:
    - <https://se-radio.net/2024/09/se-radio-632-goran-petrovic-on-mutation-testing-at-google/>
</v-clicks>

<img
  class="absolute top-5 right-110 h-25"
  src="/images/snail-pixabay.webp"
/>

---
layout: image-right
image: "/images/mutant-monster6.jpg"
---

## Mutation Strategies

🤔 How do these frameworks optimize performance?

[https://stryker-mutator.io/docs/stryker-net/technical-reference/research/#comparison](https://stryker-mutator.io/docs/stryker-net/technical-reference/research/#comparison)

- mutate **source code**
- mutate **byte code**
- **mutant schemata** (aka "mutant switching")

👉 Stryker.NET uses "mutant schemata"

---
layout: image-right
image: /images/cute-zombie3.png
---

## Live coding

---

## Reports: HTML (Overview)

<img
  class="absolute bottom-40 right-30 h-70"
  src="/images/report-example-overview-html.png"
/>

---

## Reports: HTML (Details)

<img
  class="absolute top-30 left-30 h-100"
  src="/images/report-example-details-html.png"
/>

---
layout: two-cols-header
clicks: 6
---

## Other Reporters

::left::

<v-clicks>

- [Json (basis for HTML)](https://stryker-mutator.io/docs/stryker-net/reporters/#json-reporter)
- [Progress](https://stryker-mutator.io/docs/stryker-net/reporters/#progress-reporter)
- [Cleartext](https://stryker-mutator.io/docs/stryker-net/reporters/#cleartext-reporter)
- [Cleartext tree](https://stryker-mutator.io/docs/stryker-net/reporters/#cleartext-tree-reporter)
- [Dots (for CI)](https://stryker-mutator.io/docs/stryker-net/reporters/#dots-reporter)
- [Markdown](https://stryker-mutator.io/docs/stryker-net/reporters/#markdown-summary-reporter)

</v-clicks>

::right::

<img v-click="[2]"
  class="absolute top-10 h-70"
  src="/images/report-example-overview-progress.png"
/>

<img v-click="[3]"
  class="absolute top-10 h-75"
  src="/images/report-example-overview-cleartext.png"
/>

<img v-click="[4]"
  class="absolute top-3 h-130"
  src="/images/report-example-overview-cleartexttree.png"
/>

<img v-click="[5]"
  class="absolute top-10 h-10"
  src="/images/report-example-overview-dots.png"
/>

<div v-click="[6]" style="font-size: 35%">

| File                                   | Score   | Killed | Survived | Timeout | No Coverage | Ignored | Compile Errors | Total Detected | Total Undetected | Total Mutants |
| -------------------------------------- | ------- | ------ | -------- | ------- | ----------- | ------- | -------------- | -------------- | ---------------- | ------------- |
| 00\_FizzBuzz\/FizzBuzzer.cs            | 100.00% | 14     | 0        | 0       | 0           | 4       | 0              | 14             | 0                | 18            |
| 01\_CaptainObvious\/SomeService.cs     | 75.00%  | 6      | 2        | 0       | 0           | 1       | 0              | 6              | 2                | 9             |
| 02\_OrderProcessing\/OrderProcessor.cs | 72.73%  | 8      | 3        | 0       | 0           | 3       | 0              | 8              | 3                | 14            |
| 03\_Palindrome\/PalindromeChecker.cs   | 50.00%  | 2      | 2        | 0       | 0           | 2       | 1              | 2              | 2                | 7             |

</div>

<style>
.col-bottom {
  align-self: end;
  grid-area: 3 / 1 / 4 / 3; /* Adjust this to correctly place the bottom area */
}
.two-cols-header {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: auto 1fr auto;
  column-gap: 20px; /* Adjust the gap size as needed */
}
</style>

---

## Fine-Tuning

🔧 Stryker provides many bells & whistles for fine-tuning using either [CLI or config file](https://stryker-mutator.io/docs/stryker-net/configuration/).

<v-clicks>

Some examples:

- [`mutate`](https://stryker-mutator.io/docs/stryker-net/configuration/#mutate-glob): Globbing patterns for including/excluding
- [`test-case-filter`](https://stryker-mutator.io/docs/stryker-net/configuration/#test-case-filter-string): filter selective subset(s) of tests
- [`mutation-level`](https://stryker-mutator.io/docs/stryker-net/configuration/#mutation-level-level): high level categories (`Basic`, `Standard`, `Advanced`, `Complete`)
- [`coverage-analysis`](https://stryker-mutator.io/docs/stryker-net/configuration/#coverage-analysis-string): short circuit logic vs "everything in isolation"

</v-clicks>

<v-clicks>

Also nice: use git as baseline, only test things that have changed recently

- [`since`](https://stryker-mutator.io/docs/stryker-net/configuration/#since-flag-committish): git "committish" (i.e. commit hash, tag, etc)
- [`with-baseline`](https://stryker-mutator.io/docs/stryker-net/configuration/#with-baseline-flag-committish) (experimental): similar to `since`, but uses previous reports

</v-clicks>

---
layout: image-right
image: "/images/logo-fsharp.png"
---

## What about F#?

- The team noticed they had to rearchitect the framework (.NET is not only C#)
- This is a good thing!
- Strategy is clearly communicated!
- 🥳

---

## Disclaimer: xUnit v3 is currently not supported

⚠️ Attention: Stryker.NET currently (2025-05-21) does NOT work with xUnit v3: <https://github.com/stryker-mutator/stryker-net/issues/3117>

- `VsTest`
- `MsTest`

---

## Mutation Testing: Available in many languages

Overview: <https://github.com/theofidry/awesome-mutation-testing>

- <logos-javascript /> JavaScript: <https://stryker-mutator.io/docs/stryker-js/>
- <logos-scala /> Scala: <https://stryker-mutator.io/docs/stryker4s/>
- <logos-java /> Java: <https://pitest.org/>
- <logos-python /> Python: <https://mutatest.readthedocs.io>
- <vscode-icons-file-type-cpp3 /> C/C++: <https://github.com/mull-project/mull>
- <logos-rust /> Rust: <https://mutants.rs/>
- <devicon-go /> Go: <https://github.com/zimmski/go-mutesting>
- <logos-haskell-icon /> Haskell: <https://hackage.haskell.org/package/MuCheck>
- etc. (search for "your-programming-language mutation test")

---
clicks: 4
---

## Mutation Testing: Summary

<v-clicks>

- 😎 none-invasive: no code changes required!
- 🔎 great for discovering important corner cases
- 🤔 requires a lot of resources: use wisely
- 🥳 great addition to our "Testing Toolbelt"
  - Test-Driven Development (TDD)
  - Approval Testing
  - Property-Based Testing (PBT)

</v-clicks>

<img v-click="[4]"
  class="absolute top-40 right-20 w-100"
  src="/images/toolbelt.png"
/>

---
src: ./pages/99-end.md
---
