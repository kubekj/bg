import StatisticsView from "../../../components/athlete/statistics/statistics-view";
import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";
import fetcher from "../../../lib/rest-api";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        permanent: false,
      },
    };
  }

  const options = {
    headers: {
      Authorization: `Bearer ${session.jwt}`,
    },
  };

  const weightBreakdown = await fetcher("statistics/weight", options);
  const doneTrainings = await fetcher("statistics/trainings", options);

  return {
    props: {jwt: session.jwt, weightBreakdown: weightBreakdown, doneTrainings: doneTrainings},
  };
}

const AthleteStatistics = ({ jwt, weightBreakdown, doneTrainings }) => {
  return <StatisticsView weightBreakdown={weightBreakdown} doneTrainings={doneTrainings}/>;
};

export default AthleteStatistics;

AthleteStatistics.layout = Athlete;
