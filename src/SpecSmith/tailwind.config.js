/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["**/*.razor"],
  theme: {
    extend: {},
  },
  plugins: [
    require("@tailwindcss/typography"),
    require("@tailwindcss/forms"),
    require("daisyui"),
  ],
};
