import TrainingsList from "../../../components/athlete/training/training-plans/trainings-list";
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

  const plans = await fetcher("training-plans", options);

  return {
    props: { jwt: session.jwt, plans: plans },
  };
}

const AthleteAllTrainings = ({ jwt, plans }) => {
  return <TrainingsList plans={plans} />;
};

export default AthleteAllTrainings;

AthleteAllTrainings.layout = Athlete;
