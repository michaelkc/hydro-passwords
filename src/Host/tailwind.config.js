/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{cshtml,cs}"],
  darkMode: 'selector',
  theme: {
    extend: {
      colors: {
        main: {
          DEFAULT: "hsl(var(--main))",
          foreground: "hsl(var(--main-foreground))"
        },
        primary: {
          DEFAULT: "hsl(var(--primary))",
          foreground: "hsl(var(--primary-foreground))",
          accent: "hsl(var(--primary-accent))",
        },
        secondary: {
          DEFAULT: "hsl(var(--secondary))",
          foreground: "hsl(var(--secondary-foreground))",
        },
        accent: {
          DEFAULT: "hsl(var(--accent))",
          foreground: "hsl(var(--accent-foreground))",
        },
        error: {
          DEFAULT: "hsl(var(--error))",
          foreground: "hsl(var(--error-foreground))",
        },
        control: "hsl(var(--control))",
        input: "hsl(var(--input))",
        ring: "hsl(var(--ring))",
      }
    },
  },
  plugins: []
}