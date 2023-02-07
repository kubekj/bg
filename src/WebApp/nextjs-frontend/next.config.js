/** @type {import('next').NextConfig} */
// const rewrites = () => {
//   return [
//     {
//       source: "/api/:path*",
//       destination: "http://localhost:5099/api/:path*",
//     },
//   ];
// };

const nextConfig = {
  reactStrictMode: true,
  swcMinify: true,
  async redirects() {
    return [
      {
        source: "/",
        destination: "/athlete/dashboard",
        permanent: true,
      },
    ];
  },
  // images: {
  //   loader: "akamai",
  //   path: "/",
  // },
  // rewrites,
  // env: {
  //   NEXTAUTH_URL: process.env.NEXTAUTH_URL,
  //   NEXTAUTH_SECRET: process.env.NEXTAUTH_SECRET,
  // },
};

module.exports = nextConfig;
