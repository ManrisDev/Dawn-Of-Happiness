using UnityEngine;

[System.Serializable]
public class Cat : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] private float health = 10f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;

    public float GetHeaalth() => health;

    public float GetWalkSpeed() => walkSpeed;

    public float GetRunSpeed() => runSpeed;

    public float GetJumpForce() => jumpForce;

    public void SetHealth(float health) => this.health = health;

    public void SetWalkSpeed(float walkSpeed) => this.walkSpeed = walkSpeed;

    public void SetRunSpeed(float runSpeed) => this.runSpeed = runSpeed;

    public void SetJumpForce(float jumpForce) => this.jumpForce= jumpForce;
}
