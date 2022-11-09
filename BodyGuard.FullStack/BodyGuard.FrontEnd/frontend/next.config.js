/** @type {import('next').NextConfig} */
const rewrites = () => {
  return [
    {
      source: "/api/:path*",
      destination: "http://localhost:5099/api/:path*",
    },
  ];
};

const nextConfig = {
  reactStrictMode: true,
  swcMinify: true,
  images: {
    loader: 'akamai',
    path: '/',
  },
  rewrites
}

module.exports = nextConfig
