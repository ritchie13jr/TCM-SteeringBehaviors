
public class ChaseState : BaseState
{
    private EnemyFSM enemyFSM;

    public ChaseState(EnemyFSM stateMachine) : base("chase", stateMachine)
    {
        enemyFSM = stateMachine;
    }

    public override void Update()
    {
        base.Update();

        var patrollingAgent = stateMachine.GetComponent<PatrollingAgent>();
        var enemySightSensor = stateMachine.GetComponent<EnemySightSensor>();

        patrollingAgent.SetDestination(enemySightSensor.Player.position);

        var sightSensor = stateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.Pong())
        {
            stateMachine.ChangeState(enemyFSM.patrolState);
        }
    }
}