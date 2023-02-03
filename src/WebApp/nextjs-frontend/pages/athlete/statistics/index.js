import StatisticsView from "../../../components/athlete/statistics/statistics-view";
import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";

// export async function getServerSideProps(context) {
//   const session = await getSession({req: context.req});

// if (!session) {
//   return {
//     redirect: {
//       destination: "/auth/login",
//       permanent: false,
//     },
//   };
// }
//
//   return {
//     props: { jwt: session.jwt },
//   };
// }

const AthleteStatistics = ({ jwt }) => {
  return <StatisticsView />;
};

export default AthleteStatistics;

AthleteStatistics.layout = Athlete;
