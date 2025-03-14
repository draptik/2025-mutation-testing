# README

To start the slide show locally:

- `npm install` (only needed for initial setup or when `package.json` was modified)
- `npm run dev` (or run `./start-presentation.sh`)
- visit <http://localhost:3030>

[Slidev documentation](https://sli.dev/)

## PDF

TODO

## Images

- [https://perchance.org](https://perchance.org)

## Slidev notes

### Animations

```html
<arrow v-click="[1]" x1="315" y1="310" x2="315" y2="280" color="red" width="2" arrowSize="1" />

<div v-click="[1]">
Foo
</div>
```

In the above example,

- the `arrow` element is displayed after the during click event `1` (`v-click="[1]"`). Using the array syntax makes life easier! The element is only displayed at click events included in the array.
- the `div v-click="[1]": Again, the array syntax make live easier.
